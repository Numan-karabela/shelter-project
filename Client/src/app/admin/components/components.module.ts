import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AnimalsModule } from './animals/animals.module';
import { ApplicantsModule } from './applicants/applicants.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthorizeMenuModule } from './authorize-menu/authorize-menu.module';
import { RoleModule } from './role/role.module';
 


@NgModule({
  declarations: [
   ],
  imports: [
    CommonModule,
    AnimalsModule,
    ApplicantsModule,
    DashboardModule,
    AuthorizeMenuModule,
    RoleModule
    
  ],   
  exports:[
    DashboardComponent,AnimalsModule
  ]
})
export class ComponentsModule { }
