import { Injectable } from '@angular/core';
import { HttpClientService } from '../http-client.service';
import { Create_Application } from 'src/app/contracts/application/create_aplication';
import { Observable, firstValueFrom } from 'rxjs';
import { list_Application } from 'src/app/contracts/application/list_application';

@Injectable({
  providedIn: 'root'
})
export class ApplicantService {

  constructor(private httpClientService:HttpClientService) { }

  async create(application:Create_Application):Promise<void> {
   const observable: Observable<any>=this.httpClientService.post({
    controller:"Applicant"
    },application);
    
    await  firstValueFrom(observable); 

  }

  async getAllOrders():Promise<list_Application[]> {
    const observable: Observable<list_Application[]>=this.httpClientService.get({
     controller:"Applicant"
     });
     
     return await  firstValueFrom(observable);
     
   }
}
