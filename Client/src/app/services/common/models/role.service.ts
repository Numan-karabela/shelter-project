import { Injectable } from '@angular/core';
import { HttpClientService } from '../http-client.service';
import { Observable, firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  constructor(private htpCliendService:HttpClientService) { }

 async  getRoles(page:number,size:number,succededCallback?:()=>void, errorCallBack?:(error)=>void)
    {
     const observabler:Observable<any>=this.htpCliendService.get({
     controller:"roles",

     });
      const promisedata=firstValueFrom(observabler);
      promisedata.then(succededCallback)
      .catch(errorCallBack);
 
      return await promisedata;
    }


   async create(name:string,succededCallback?:()=>void,errorCallBack?:(Error)=>void){
   const observabler:Observable<any>=this.htpCliendService.post({
    controller:"roles"
   },{name:name});
    

   const promisedata= firstValueFrom(observabler);
   promisedata.then(succededCallback)
    .catch(errorCallBack);


    return await promisedata as {succeeded:boolean}; 
   
    }
    



}
