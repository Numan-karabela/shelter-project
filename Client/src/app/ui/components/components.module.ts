import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
 import { ApplicantsModule } from 'src/app/admin/components/applicants/applicants.module';
import { DonationModule } from './donation/donation.module';
import { HomeModule } from './home/home.module';
 import { RegisterModule } from './register/register.module';
import { LoginComponent } from './login/login.component';
import { LoginModule } from './login/login.module';
import { ApplicantsComponent } from 'src/app/admin/components/applicants/applicants.component';
import { ApplicationModule } from './application/application.module';
import { AnimalsModule } from 'src/app/admin/components/animals/animals.module';
import { PasswordResetComponent } from './password-reset/password-reset.component';
import { UpdatePasswordComponent } from './update-password/update-password.component';
import { PasswordResetModule } from './password-reset/password-reset.module';
import { UpdatePasswordModule } from './update-password/update-password.module';



@NgModule({
  declarations: [  
    
  ],
  imports: [
    CommonModule,
    AnimalsModule,
    ApplicantsModule,
    DonationModule,
    HomeModule,
    RegisterModule,
    // LoginModule
    PasswordResetModule,
    UpdatePasswordModule
    
  ],exports:[
    ApplicantsModule
  ]
})
export class ComponentsModule { }
