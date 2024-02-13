import { ComponentFactoryResolver, Injectable, ViewContainerRef } from '@angular/core';
import { BaseComponent } from 'src/app/base/base.component';

@Injectable({
  providedIn: 'root'
})
export class DynamicLoadCompService {

 //ViewContainerRef     :Dinamik olarak yüklenicek componenti içersinde barındıran kontainardır
   //ComponentFactory     : Componetlerin instaclarını olusturmak için kullanılar nesnedir.
   //ComponentFactoryResolver   :Belirli bir component için ComponentFactory'i resolve eden sınıftır. resolve eden sınıftır
   // içerisindeki resolveComponentFactory  fonksiyonu aracılığıyla ilgili componente dair bir ComponentFactory nesnesi oluşturur
   //

  constructor( ) { }
   
  

   async loadComponent(component:ComponentType,viewContainerRef:ViewContainerRef){
    

     let  _component:any=null;
      
      switch(component){
         case ComponentType.BasketsComponent:
           _component=(await import ("../../ui/components/application/application.component")).ApplicationComponent;
           break; 
      }

      viewContainerRef.clear();
      return viewContainerRef.createComponent( _component) 



  }
}

export enum ComponentType{
  
 BasketsComponent

  
}