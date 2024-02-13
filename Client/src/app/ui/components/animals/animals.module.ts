import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AnimalsComponent } from './animals.component';
import { RouterModule } from '@angular/router';
import { ListComponent } from './list/list.component';



@NgModule({
  declarations: [
    AnimalsComponent,
    ListComponent
  ],
  imports: [
    CommonModule,
    
    RouterModule.forChild([
      {path:"",component:AnimalsComponent}
    ])
  ]
})
export class AnimalsModule { }
