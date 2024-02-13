using BarinakAPI.Application.Abstractions.Services;
using BarinakAPI.Application.Repositories;
using BarinakAPI.Application.ViewModel.Baskets;
using BarinakAPI.Domain.Entities;
using BarinakAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BarinakAPI.Persistence.Services
{
    public class BasketService : IBasketService
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly UserManager<AppUser> _userManager;
        readonly IApplicantReadRepository _applicantReadRepository;

        readonly IBasketWriteRepository _basketWriteRepository;
        readonly IBasketReadRepository _basketReadRepository;
        
        readonly IBasketItemWriteRepository _basketItemWriteRepository;
        readonly IBasketItemReadRepository _basketItemReadRepository;

        public BasketService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IBasketWriteRepository basketWriteRepository, IBasketItemWriteRepository basketItemWriteRepository, IBasketItemReadRepository basketItemReadRepository, IApplicantReadRepository applicantReadRepository, IBasketReadRepository basketReadRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;

            _applicantReadRepository = applicantReadRepository;

            _basketItemWriteRepository = basketItemWriteRepository;
            _basketItemReadRepository = basketItemReadRepository;
           

            _basketReadRepository = basketReadRepository;
            _basketWriteRepository = basketWriteRepository;
        }

        private async Task<Basket?> ContextUser()
        {

            var username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
            if (!string.IsNullOrEmpty(username))
            {   
               AppUser? user =  await  _userManager.Users
                    .Include(u => u.Baskets)
                     .FirstOrDefaultAsync(u => u.UserName == username);


                var _basket = from basket in user.Baskets
                              join applicant in _applicantReadRepository.Table
                              on basket.Id equals applicant.Id into Basketapplicants
                              from ba in Basketapplicants.DefaultIfEmpty()
                              select new
                              {

                                 Basket= basket,
                                 Applicant=ba
                              };

                Basket? targetBasket = null;
                if (_basket.Any(b => b.Applicant is null))
                    targetBasket = _basket.FirstOrDefault(b => b.Applicant is null)?.Basket;
                else
                {
                    targetBasket = new();
                    user.Baskets.Add(targetBasket);

                }
                    await _basketWriteRepository.SaveAsync();
                    return targetBasket;
           
            }
            throw new Exception("Beklenmeyen bir hata olustu");
        }

        public async Task AddItemToBasketAsync(VM_Create_BasketItem basketItem)
        {
            Basket? basket =await ContextUser();
            if (basket!=null)
            {
              BasketItem _basketItem = await _basketItemReadRepository.GetSingeldAsync(bi => bi.BasketId == basket.Id && bi.AnimalId==
                Guid.Parse(basketItem.AnimalId));
                if (_basketItem != null)
                    _basketItem.Quentity++;
                else
                    await _basketItemWriteRepository.AddAsync(new()
                    {
                        BasketId=basket.Id,
                        AnimalId = Guid.Parse(basketItem.AnimalId),
                        Quentity=basketItem.Quantity
                    });

                await _basketItemWriteRepository.SaveAsync();

            }



        }

        public async Task<List<BasketItem>> GetBasketItemsAsync()
        {
            Basket? basket=await ContextUser();
            Basket? result = await _basketReadRepository.Table
                  .Include(b => b.BasketItems)
                  .ThenInclude(bi => bi.Animal)
                  .FirstOrDefaultAsync(b => b.Id == basket.Id);

            return result.BasketItems
                .ToList();
             
        }




        public async Task RemoveBasketItemAsync(string basketItemId)
        {

            BasketItem? basketItem = await _basketItemReadRepository.GetByIdAsync(basketItemId);
            if (basketItem !=null)
            {
                _basketItemWriteRepository.Remove(basketItem);
                await _basketItemWriteRepository.SaveAsync();

            }

        }

        public async Task UpdateQuentityAsync(VM_Update_BasketItem basketItem)
        {
           BasketItem? _basketItem = await _basketItemReadRepository.GetByIdAsync(basketItem.BasketItemId) ;
            if(_basketItem !=null)
            {
                _basketItem.Quentity = basketItem.Quantity;
                await _basketItemWriteRepository.SaveAsync();

            }


        }

      
        public Basket? GetUserActiveBasket
        {
            get
            {

                Basket? basket = ContextUser().Result;

                return basket;
            }
        }
    }
}
