import { Injectable } from '@angular/core';
import { HttpClientService } from '../http-client.service';
import { Create_Animal } from 'src/app/contracts/create_animal';
import { list_Animal } from 'src/app/contracts/list_animal';
import { async } from '@angular/core/testing';
import { HttpErrorResponse } from '@angular/common/http';
import { Observable, firstValueFrom } from 'rxjs';
import { list_Animal_image } from 'src/app/contracts/list_animal_image';

@Injectable({
  providedIn: 'root'
})
export class AnimalService {

  constructor(private httpClientService:HttpClientService ) { }


  create(animal:Create_Animal,successCallBack?: ()=>void , errorCallBack?:(errorMessage:string)=>
  void){
    
 this.httpClientService.post({
controller:"product",
},animal).subscribe(result=>{
  successCallBack(); 
},(errorRecponse:HttpErrorResponse)=>{
  const _error:Array<{key:string,value:Array<string>}>= errorRecponse.error;
  let message="";
  _error.forEach((v,index)=>{
    v.value.forEach((_v,_index)=>{
      message+=`${_v}<br>`;
    });
  });
    errorCallBack(message);
},
);



 }
  
async read(page:number=0,size:number=5, successCallBack?:()=>void,errorCallBack?:
(errorMessage:string)=>void):Promise<{totalAnimalCount:number;animals:list_Animal[] }>{
  const promiseData:Promise<{totalAnimalCount:number;animals:list_Animal[]}>= 
  this.httpClientService.get<{totalAnimalCount:number;animals:list_Animal[] }>({ 
    
  controller:"product",
  queryString:`page=${page}&size=${size}`

  }).toPromise();

  promiseData.then(d=>successCallBack())
  .catch((errorRecponse:HttpErrorResponse)=>errorCallBack(errorRecponse.message))

  return await promiseData;
}
 
     async delete(id:string){
     const deleteObservable:Observable<any>= this.httpClientService.delete<any>({
     controller:"product"
    },id);
   
    await firstValueFrom(deleteObservable);

}


async readImage(id:string,successCallBack?:()=>void):Promise<list_Animal_image[]>{
 const getObservable:Observable<list_Animal_image[]>=this.httpClientService.get<list_Animal_image[]>({
action:"GetAnimalImage",
controller:"product"
},id);

const images:list_Animal_image[]=await firstValueFrom(getObservable);
successCallBack();
return images;

}
async deleteImage(id:string, imageId:string,successCallBack?:()=>void){

 const deleteObservable= this.httpClientService.delete({

  action:"deleteanimalimage",
  controller:"product",
  queryString:`imageId=${imageId}`

},id)

await firstValueFrom(deleteObservable);
successCallBack();

}

async chanceShowcaseImage(imageId:string,animalId:string,successCallBack?:()=>void):Promise<void>
{
const changeShowcaseImageObservable= this.httpClientService.put({
  controller:"product",
  action:"ChangeShowcaseImage",
  queryString:`imageId=${imageId}&animalId=${animalId}`,
},{});
 await firstValueFrom(changeShowcaseImageObservable);
 successCallBack();
}
}
