import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './admin/layout/layout.component';
import { DashboardComponent } from './admin/components/dashboard/dashboard.component';
import { HomeComponent } from './ui/components/home/home.component';
import { AuthGuard } from './guards/comman/auth.guard';

const routes: Routes = [
  {path:"admin",component:LayoutComponent,children:[
    {path:"",component:DashboardComponent,canActivate:[AuthGuard]},
    {path:"animals",loadChildren:()=>import("./admin/components/animals/animals.module").then
  (module=>module.AnimalsModule),canActivate:[AuthGuard]},
  {path:"applicants",loadChildren:()=>import("./admin/components/applicants/applicants.module").then
  (module=>module.ApplicantsModule),canActivate:[AuthGuard]},
  {path:"",loadChildren:()=>import("./admin/components/dashboard/dashboard.module").then
  (module=>module.DashboardModule),canActivate:[AuthGuard]},
  {path:"authorize-menu",loadChildren:()=>import("./admin/components/authorize-menu/authorize-menu.module").then
  (module=>module.AuthorizeMenuModule),canActivate:[AuthGuard]},
  {path:"roles",loadChildren:()=>import("./admin/components/role/role.module").then
  (module=>module.RoleModule),canActivate:[AuthGuard]},
  ],canActivate:[AuthGuard]

},
  {path:"",component:HomeComponent},
  {path:"animals",loadChildren:()=>import("./ui/components/animals/animals.module").then
  (module=>module.AnimalsModule)},
  {path:"animals/:pageNo",loadChildren:()=>import("./ui/components/animals/animals.module").then
  (module=>module.AnimalsModule)},
  {path:"application",loadChildren:()=>import("./ui/components/application/application.module").then
  (module=>module.ApplicationModule)},
  {path:"donation",loadChildren:()=>import("./ui/components/donation/donation.module").then
  (module=>module.DonationModule)},
  {path:"register",loadChildren:()=>import("./ui/components/register/register.module").then
  (module=>module.RegisterModule)},
  {path:"password-reset",loadChildren:()=>import("./ui/components/password-reset/password-reset.module").then
  (module=>module.PasswordResetModule)},
  {path:"update-Password/userId/:resetToken",loadChildren:()=>import("./ui/components/update-password/update-password.module").then
  (module=>module.UpdatePasswordModule)},
  
  {path:"login",loadChildren:()=>import("./ui/components/login/login.module").then
  (module=>module.LoginModule)},
  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
