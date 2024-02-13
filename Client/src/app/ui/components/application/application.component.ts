import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component'; 
import { Create_Application } from 'src/app/contracts/application/create_aplication';
import { Application_Basket_Item } from 'src/app/contracts/basket/application_basket_items'; 
import { ApplicantService } from 'src/app/services/common/models/Applicant.service';
import { ApplicationService } from 'src/app/services/common/models/application.service';
import { Basket_ApplicationService } from 'src/app/services/common/models/basket_Applicant.service';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from 'src/app/services/ui/custom-toastr.service';
 declare var $:any;
 


@Component({
  selector: 'app-application',
  templateUrl: './application.component.html',
  styleUrls: ['./application.component.scss']
})
export class ApplicationComponent extends BaseComponent {

  constructor( spinner:NgxSpinnerService,private basketService:Basket_ApplicationService,
    private applicationService:ApplicantService,private toastrService:CustomToastrService,private router:Router){
    super(spinner)
        
      }
    
    
      basketItems:Application_Basket_Item[];
    async ngOnInit():Promise<void>{ 
      this.Spannershow(SpinnerType.BallAtom)
      this.basketItems=await this.basketService.get()
      this.HideSpennar(SpinnerType.BallAtom)

    
    }
        //  changeQuentity/(objeck:any){
          //  BU KISIM KULLANMAIYCAM
          
        //  } 
      async  removeBasketItem(basketItemId:string){
            this.Spannershow(SpinnerType.BallAtom) 
           await this.basketService.remove(basketItemId); 
           $("."+basketItemId).fadeOut(500,()=> this.HideSpennar(SpinnerType.BallAtom));
     }


       async shoppingComplete (){ 
          this.Spannershow(SpinnerType.BallAtom);
          const application:Create_Application=new Create_Application();
          application.address="Trabzon";
          application.description="merkez";
          await this.applicationService.create(application);     
         this.HideSpennar(SpinnerType.BallAtom); 
         this.toastrService.message("Başvurunuz oluşturulmustur","Başvurunuz oluştu",{
          messageType:ToastrMessageType.Success,
          position:ToastrPosition.TopRight
         })        
          this.router.navigate(["/"])
        }
       

  }