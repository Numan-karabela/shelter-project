import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { NgxSpinnerService } from "ngx-spinner";
import { BaseComponent, SpinnerType } from "src/app/base/base.component";
import { AlertifyService, MessageType, Position } from "src/app/services/admin/alertify.service";
import { UserAuthServiceService } from "src/app/services/common/models/user-auth.service.service";
import { UserService } from "src/app/services/common/models/user.service";

 
@Component({
  selector: 'app-update-password',
  templateUrl: './update-password.component.html',
  styleUrls: ['./update-password.component.scss']
})
export class UpdatePasswordComponent extends BaseComponent implements OnInit {

  constructor(spinner:NgxSpinnerService,
    private router:Router,
    private userService:UserService,
    private userAuthService:UserAuthServiceService,
    private activatedRouth:ActivatedRoute,
    private alertfyService:AlertifyService){
  super(spinner)
   
  }   
  
   state: any;
  
  
  ngOnInit():void{
    this.Spannershow(SpinnerType.BallAtom)
    this.activatedRouth.params.subscribe({
         next:async params=>{
         const userId:string= params["userId"];
         const resetToken:string= params["resetToken"];
        this.state= await  this.userAuthService.verifyResetToken(resetToken,userId,()=>{
         this.HideSpennar(SpinnerType.BallAtom);  
          })
         } 
    });
  }

  updatePassword(passwordConfirm:string,password:string)
   {
     this.Spannershow(SpinnerType.BallAtom);
     if(password!=passwordConfirm){
      
     this.alertfyService.message("şifreyi doğrulayiniz",{
     messageType:MessageType.Error,
     position:Position.TopRight 
      });
      this.HideSpennar(SpinnerType.BallAtom)
      return;
    }

    this.activatedRouth.params.subscribe({
      next: async params=>{
        const userId:string= params["userId"];
        const resetToken:string= params["resetToken"];
        await this.userService.updatePassword(userId,resetToken,password,passwordConfirm,
          ()=>{
          this.alertfyService.message("şifre başarıyla güncellendi",{
            messageType:MessageType.Success,
            position:Position.TopRight
          }) 
          this.router.navigate(["/login"])
        },
        error=>{
        
       console.log(error)
        });
          this.HideSpennar(SpinnerType.BallAtom)
      }
    })

   }
   }
