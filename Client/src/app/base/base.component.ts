import { Component } from '@angular/core';
import { NavigationExtras } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';

 
export class BaseComponent
 {

  constructor (private spinner:NgxSpinnerService ){}

  Spannershow(spinnerNameType:SpinnerType){

     this.spinner.show(spinnerNameType)
     setTimeout(()=>this.HideSpennar(spinnerNameType),3000);

  }




  HideSpennar(spinnerNameType:SpinnerType)
  {
    this.spinner.hide(spinnerNameType);
   }

}

 

export enum SpinnerType{
BallAtom="s1",
ballscalemultiple="s2"
}
