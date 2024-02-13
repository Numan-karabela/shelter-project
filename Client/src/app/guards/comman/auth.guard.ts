import { Inject, Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Route, Router, RouterStateSnapshot,UrlTree } from "@angular/router";
import { JwtHelperService } from "@auth0/angular-jwt";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { SpinnerType } from "src/app/base/base.component";
import { AuthService, _isAuthenticated } from "src/app/services/common/auth.service";
import { CustomToastrService, ToastrMessageType, ToastrPosition } from "src/app/services/ui/custom-toastr.service";

@Injectable({
  providedIn:'root'
}) 

export class AuthGuard implements CanActivate{

  constructor(private jwtHelper:JwtHelperService,
    private router:Router ,
    private toastrService:CustomToastrService,
    private spinner:NgxSpinnerService,
    private authService:AuthService){


  }

 canActivate(route:ActivatedRouteSnapshot,state:RouterStateSnapshot){
 this.spinner.show(SpinnerType.BallAtom)
  // const token:string=localStorage.getItem("accessToken"); 
  //  const decodeToken= this.jwtHelper.decodeToken(token);
  // const expirationDate:Date=this.jwtHelper.getTokenExpirationDate(token);
  // let expired:boolean;
  // try{
  //   expired=this.jwtHelper.isTokenExpired(token);
    
  // }
  // catch
  // {

  //   expired=true;
  // }

  if(!_isAuthenticated)
  {
  this.router.navigate(["login"],{queryParams:{returnUrl:state.url}});
 this.toastrService.message("Oturum açmak gerekiyor","Yetkisiz erişim!",{
  messageType:ToastrMessageType.Warning,
  position:ToastrPosition.TopRight
 })


  }
 this.spinner.hide(SpinnerType.BallAtom);

  return true;
 }

}