import { Component,OnInit } from '@angular/core';
import { tick } from '@angular/core/testing';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType, } from 'src/app/base/base.component';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { UserAuthServiceService } from 'src/app/services/common/models/user-auth.service.service';

@Component({
  selector: 'app-password-reset',
  templateUrl: './password-reset.component.html',
  styleUrls: ['./password-reset.component.scss']
})
export class PasswordResetComponent extends BaseComponent {
  
  constructor(spinner:NgxSpinnerService ,private userAuthServie:UserAuthServiceService,private alertifyService:AlertifyService){
    super(spinner)
  }
   
  passwordReset(email:string){
     this.userAuthServie.passwordReset(email,()=>{
      this.HideSpennar(SpinnerType.BallAtom)
      this.alertifyService.message("Mail adresinize sıfırlama bağlantısı gönderilmiştir",{
        messageType:MessageType.Message,
        position:Position.TopRight
      })

     })

  }

   
}
