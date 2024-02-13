import { Injectable } from '@angular/core';
import { HttpClientService } from '../http-client.service';
import { Application_Basket_Item } from 'src/app/contracts/basket/application_basket_items';
import { firstValueFrom,Observable, observeOn } from 'rxjs';
import { Create_Applicationce_Basket_Items } from 'src/app/contracts/basket/create_application_basket_items';
import { Update_Application_Basket_Items } from 'src/app/contracts/basket/update_application_basket_items';

@Injectable({
  providedIn: 'root'
})
export class Basket_ApplicationService {

  constructor(private httpClientService:HttpClientService) { }

 async get():Promise<Application_Basket_Item[]>{
         
    const Observable: Observable<Application_Basket_Item[]>=this.httpClientService.get({
    
     controller:"baskets"
    });

  return  await firstValueFrom(Observable)

}


  async add(basketItem:Create_Applicationce_Basket_Items  ):Promise<void>{
   const Observable:Observable<any>=this.httpClientService.post({
      controller:"baskets"
   },basketItem);

 
    await firstValueFrom(Observable)
   }



   async put(basketItem:Update_Application_Basket_Items):Promise<any>{
   const observeOn:Observable<any>=this.httpClientService.put({
   controller:"baskets"

   },basketItem)

   await firstValueFrom(observeOn)

   }


  async remove(basketItemId:string){
  const observeOn:Observable<any>=this.httpClientService.delete({
    controller:"baskets"
  },basketItemId);
 
  await firstValueFrom(observeOn)

  }

}
 
