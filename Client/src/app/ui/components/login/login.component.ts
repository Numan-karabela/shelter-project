import { SocialAuthService, SocialUser } from '@abacritt/angularx-social-login';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { AuthService } from 'src/app/services/common/auth.service';
import { UserService } from 'src/app/services/common/models/user.service';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/compiler';
import { HttpClientService } from 'src/app/services/common/http-client.service';
import { TokenResponse } from 'src/app/contracts/token/TokenResponse';
import { async } from 'rxjs';
import { UserAuthServiceService } from 'src/app/services/common/models/user-auth.service.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent extends BaseComponent implements OnInit {

constructor(
  private userAuthService:UserAuthServiceService,spinner:NgxSpinnerService,
  private authService:AuthService,
  private activatedRount:ActivatedRoute,
  private router:Router,
  private socialAuthService:SocialAuthService, 



  ) {


super(spinner)
socialAuthService.authState.subscribe(async(user:SocialUser)=>{
console.log(user)
this.Spannershow(SpinnerType.BallAtom);
await userAuthService.googleLogin(user , ()=>{
  this.authService.identityCheck();
  this.HideSpennar(SpinnerType.BallAtom);

})

});

} 

ngOnInit(): void {
  
}
async login(usernameOrEmail:string,password:string){
this.Spannershow(SpinnerType.BallAtom);

 await this.userAuthService.login(usernameOrEmail,password,()=>{
  this.authService.identityCheck();  
  
  this.activatedRount.queryParams.subscribe(params=>{
   const returnUrl:string=params["returnUrl"];
   if(returnUrl)
  this.router.navigate([returnUrl]);
 
  });

  this.HideSpennar(SpinnerType.BallAtom)
});
}
}
