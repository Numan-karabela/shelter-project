import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { RouterModule } from '@angular/router'; 
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/compiler';



@NgModule({
  declarations: [/*LoginComponent*/],
  imports: [
    CommonModule,
    RouterModule.forChild([
    {path:"",component:LoginComponent,}
    ]),
  ]
})
export class LoginModule { }
