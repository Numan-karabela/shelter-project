import { Component, ViewChild } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CustomToastrService,ToastrMessageType, ToastrPosition, } from './services/ui/custom-toastr.service';
import { AuthService } from './services/common/auth.service';
import { Route, Router } from '@angular/router';
import { HttpClientService } from './services/common/http-client.service';
import { ComponentType, DynamicLoadCompService } from './services/common/dynamic-load-comp.service';
import { DynamicLoadComponentDirective } from './directives/common/dynamic-load-component.directive';
  declare var $:any

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent { 
   @ViewChild(DynamicLoadComponentDirective,{static:true})
   dynamicLoadComponentDirective:DynamicLoadComponentDirective;


  constructor(public authService:AuthService,private toastrService:CustomToastrService,private router:Router,
  private httpClientService:HttpClientService ,private dynamicLoadComponentService:DynamicLoadCompService){

    authService.identityCheck();
  }




  sigOut(){
 localStorage.removeItem("accessToken");
 this.authService.identityCheck();

 this.router.navigate([""]);
  
 this.toastrService.message("Oturum kapatılmıştır!","Oturum kapandı",{
  messageType:ToastrMessageType.Warning,
  position:ToastrPosition.TopRight
 });
}
 
loadComponent(){
   this.dynamicLoadComponentService.loadComponent(ComponentType.BasketsComponent,
    this.dynamicLoadComponentDirective.viewContainerRef);


 }
}  