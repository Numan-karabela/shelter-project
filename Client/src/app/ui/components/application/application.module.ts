import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApplicationComponent } from './application.component';
import { RouterModule } from '@angular/router';
import { BaseComponent } from 'src/app/base/base.component';
import { AppComponent } from 'src/app/app.component';



@NgModule({
  declarations: [
    ApplicationComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path:"",component:ApplicationComponent}
    ])
  ],
  exports:[
    ApplicationComponent
  ]
})
export class ApplicationModule { }
