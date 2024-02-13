import { Component, OnInit } from '@angular/core'; 
import { ActivatedRoute } from '@angular/router'; 
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { Application_Basket_Item } from 'src/app/contracts/basket/application_basket_items';
import { Create_Applicationce_Basket_Items } from 'src/app/contracts/basket/create_application_basket_items';
import { BaseUrl } from 'src/app/contracts/base_url';
import { list_Animal } from 'src/app/contracts/list_animal';
import { AnimalService } from 'src/app/services/common/models/animal.service'; 
import { Basket_ApplicationService } from 'src/app/services/common/models/basket_Applicant.service';
import { FileService } from 'src/app/services/common/models/file.service';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from 'src/app/services/ui/custom-toastr.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent extends BaseComponent implements OnInit {
   
  constructor(private animalService:AnimalService, private activatedRoute:ActivatedRoute ,private fileService:FileService,
    private basketService:Basket_ApplicationService, spinner:NgxSpinnerService,private customToastrService:CustomToastrService
    ){ 
      super(spinner)
    }


currentPageNo:number;
totalAnimalCount:number;
totalPageCount:number;
pageSize:number=12;
pageList:number[]=[];
baseUrl:BaseUrl;
 

animals :list_Animal[];

async ngOnInit() {
   this.baseUrl=await this.fileService.getBaseStorageUrl(); 

  this.activatedRoute.params.subscribe(async params=>{
   this.currentPageNo=parseInt(params["pageNo"] ?? 1);
 
     

    const data:{totalAnimalCount:number,animals:list_Animal[]} =await
    this.animalService.read(this.currentPageNo -1,this.pageSize,
    ()=>{  
    },
    errorMessage=>{

    });


    this.animals=data.animals;
    
    this.animals=this.animals.map<list_Animal>(p=>{
     const listAnimal: list_Animal={
      id:p.id,
      age:p.age,
      imagePath:`${ p.animalImageFiles.length?p.animalImageFiles.find(p=>p.showcase).Path:""}`, 
      name:p.name,
      gender:p.gender,
      vaccination:p.vaccination,
      type:p.type, 

      animalImageFiles:p.animalImageFiles,


     }

     return new list_Animal();
    });

  
    
    this.totalAnimalCount=data.totalAnimalCount;
    this.totalPageCount=Math.ceil(this.totalAnimalCount/this.pageSize);
    
    this.pageList=[];

       if(this.currentPageNo-3<=0)
       for(let i=1; i<=7; i++)
       this.pageList.push(i);
       
       else if(this.currentPageNo + 3 >=this.totalPageCount)
       for(let i=this.totalPageCount-6; i<=this.totalPageCount; i++)
      this.pageList.push(i);

      else
      for(let i=this.currentPageNo-3; i<=this.currentPageNo + 3; i++)
      this.pageList.push(i);

  });

 }


 async addToBasket(animal:list_Animal){
        this.Spannershow(SpinnerType.BallAtom)
        let _basketItem:Create_Applicationce_Basket_Items=new Create_Applicationce_Basket_Items();
        _basketItem.animalId=animal.id
        _basketItem.quantity=1;
  await this.basketService.add(_basketItem);
  this.HideSpennar(SpinnerType.BallAtom)
  this.customToastrService.message("Başvuru eklendi","Basvuru Eklendi",{
  messageType:ToastrMessageType.Success,
  position:ToastrPosition.TopRight

  });


   }
}
