import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DonationComponent } from './donation.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    DonationComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path:"",component:DonationComponent}
    ])
  ]
})
export class DonationModule { }
