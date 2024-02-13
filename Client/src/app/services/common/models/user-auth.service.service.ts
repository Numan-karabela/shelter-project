import { Injectable } from '@angular/core';
import { HttpClientService } from '../http-client.service';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../../ui/custom-toastr.service';
import { TokenResponse } from 'src/app/contracts/token/TokenResponse';
import { Observable } from 'rxjs/internal/Observable';
import { firstValueFrom } from 'rxjs/internal/firstValueFrom';
import { SocialUser } from '@abacritt/angularx-social-login';

@Injectable({
  providedIn: 'root'
})
export class UserAuthServiceService {
  [x: string]: any;

  constructor(private httpClientService:HttpClientService,
    private toastrService:CustomToastrService,
     ) {}
  async login(usernameOrEmail:string,password:string, callbackFunction?:()=>void):Promise<any>
  {
  const observable:Observable< any | TokenResponse  >= this.httpClientService.post<any | TokenResponse >({
  controller:"auth",
  action:"login"
  },{ usernameOrEmail,password})
  
  
    const tokenResponse:TokenResponse= await firstValueFrom(observable) as TokenResponse;
  
    if(tokenResponse){
      localStorage.setItem("accessToken",tokenResponse.token.accessToken);
      localStorage.setItem("refreshToken",tokenResponse.token.refreshToken);

      
  this.toastrService.message("Kullanıcı girişi başarılı","Giriş başarılı",{
    messageType:ToastrMessageType.Success,
    position:ToastrPosition.TopRight
   
    })
  }
  
  callbackFunction(); 
  
  }
   
async refreshTokenLogin(refreshToken:string,callbackFunction?:(state)=>void):Promise<any>{
const observable: Observable<any| TokenResponse>=this.httpClientService.post({
action:"refreshtokenlogin",
controller:"auth"

},{refreshToken:refreshToken});

try{ 
  const tokenResponse:TokenResponse=await firstValueFrom(observable)as TokenResponse;
  if(tokenResponse){
  
    localStorage.setItem("accessToken",tokenResponse.token.accessToken);
    localStorage.setItem("refreshToken",tokenResponse.token.refreshToken);
  
  }
  callbackFunction(tokenResponse ? true:false);


}
catch{

  callbackFunction(false);
}

}

  async googleLogin(user:SocialUser,  callbackFunction?:()=>void):Promise<any> {
   const observable:Observable<SocialUser| TokenResponse>= this.httpClientService.post<SocialUser| TokenResponse>({
      action:"google-login",
      controller:"auth",
    },user) ;
   
   const tokenResponse:TokenResponse= await firstValueFrom(observable) as TokenResponse;
  
  if(TokenResponse){
    
  localStorage.setItem("accessToken",tokenResponse.token.accessToken);
  localStorage.setItem("refreshToken",tokenResponse.token.refreshToken);

   this.toastrService.message("Google üzerinde giriş başarılı","GİRİŞ BAŞARILI",
   {
    messageType:ToastrMessageType.Success,
    position:ToastrPosition.TopRight
   });
  }
  callbackFunction();
  }

 async passwordReset (email:string, callbackFunction?:()=>void){
   const observable :Observable<any>=this.httpClientService.post({
    controller:"aauth",
    action:"password-reset"
   },{email:email});
        await firstValueFrom(observable);
        callbackFunction();
      
 }

 async verifyResetToken(refreshToken:string,userId:string,callbackFunction?:()=>void):Promise<Boolean>
  {
    const observable :Observable<any>=this.httpClientService.post({
      
    controller:"auth",
    action:"verify-reset-token"
   },{
      resetToken:refreshToken,
      userId:userId
  
  
  });
    const state : boolean = await firstValueFrom(observable);
        callbackFunction();
        return state;
 }

}
