import { CommonModule } from '@angular/common'; 
import { ComponentsModule } from './components/components.module';
import { NgModule } from '@angular/core';



@NgModule({
  declarations: [ 
  ],
  imports: [
    CommonModule ,ComponentsModule
  ],
  exports:[
    ComponentsModule
  ]
})
export class UiModule { }
