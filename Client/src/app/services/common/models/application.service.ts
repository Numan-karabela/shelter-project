import { Injectable } from '@angular/core';
import { HttpClientService } from '../http-client.service';

import { Observable, firstValueFrom } from 'rxjs';
import { Menu } from 'src/app/contracts/aplication-configuration/Menu';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {

  constructor(private httpclientService:HttpClientService) { }




 async getAuthorizeDefinitionEndpoints(){
    const observable:Observable<Menu[]>=this.httpclientService.get({
   controller:"ApplicationServices"
    });
 return firstValueFrom(observable);

  }
}
