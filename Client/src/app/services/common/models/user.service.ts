import { Injectable } from '@angular/core';
import { HttpClientService } from '../http-client.service';
import { User } from 'src/app/entitys/user';
import { Create_User } from 'src/app/contracts/Users/create_users';
import { Observable, ObservableInput, firstValueFrom } from 'rxjs';
 import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../../ui/custom-toastr.service';
import { Token } from 'src/app/contracts/token/token';
import { TokenResponse } from 'src/app/contracts/token/TokenResponse';
import { SocialUser } from '@abacritt/angularx-social-login';
import { LocalizedString } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClientService:HttpClientService,
    private toastrService:CustomToastrService,
     ) {}


  async Create(user:User):Promise<Create_User>   {
    const observable: Observable<Create_User | User> =this.httpClientService.post<Create_User | User> ({
   controller:"users"
   },user);
     
   return await firstValueFrom(observable) as Create_User;
 }

 async updatePassword(userId:string,resetToken:string,password:string ,passwordConfirm:string,successCallback?:()=>void,errorcallback?:(error)=>void)
 { 
    const observable:Observable<any>=this.httpClientService.post({
      action:"update-password",
      controller:"users"
    },{
     userId:userId,
     resetToken:resetToken,
     password:password,
     passwordConfirm:passwordConfirm

    });
   const promiseDate:Promise<any>=await firstValueFrom(observable);
   promiseDate.then(value=>successCallback()).catch(error=>errorcallback(error));
   await promiseDate;


 }

}
