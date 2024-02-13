import { NgModule,Component,OnInit } from '@angular/core';
import { CommonModule,  } from '@angular/common'; 
import { ActivatedRoute, RouterModule } from '@angular/router';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { NgxSpinnerService } from 'ngx-spinner';
import { UserAuthServiceService } from 'src/app/services/common/models/user-auth.service.service'; 
import { state } from '@angular/animations'; 
import { UpdatePasswordComponent } from './update-password.component';
 



@NgModule({
  declarations: [
    UpdatePasswordComponent
  ],
  imports:[
    CommonModule,
    RouterModule.forChild([
      {path:"",component:UpdatePasswordComponent}
    ]),
  ]
})

export class UpdatePasswordModule { }