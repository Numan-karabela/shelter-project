import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AdminModule } from './admin/admin.module';
import { UiModule } from './ui/ui.module';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner'; 
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http'; 
import { JwtModule } from '@auth0/angular-jwt';
import { LoginComponent } from './ui/components/login/login.component';
import { GoogleLoginProvider, GoogleSigninButtonModule, SocialAuthServiceConfig, SocialLoginModule } from '@abacritt/angularx-social-login';
import { HttpErrorHandlerInterceptorService } from './services/common/http-error-handler-interceptor.service';
import { DynamicLoadComponentDirective } from './directives/common/dynamic-load-component.directive';
 
 @NgModule({
  declarations: [
    AppComponent ,
    LoginComponent,
    DynamicLoadComponentDirective
    ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AdminModule,
    UiModule,
    ToastrModule.forRoot(),
    NgxSpinnerModule,
    HttpClientModule,
    JwtModule.forRoot({
      config:{
        tokenGetter:()=>localStorage.getItem("accessToken"),
        allowedDomains:["localhost:7224"],
      }
    }),

SocialLoginModule, 
GoogleSigninButtonModule
  ],
  providers: [
 { provide:"baseUrl",useValue:"https://localhost:7224/api",multi:true},
 { provide:"baseSignalRUrl",useValue:"https://localhost:7224/",multi:true},


 {
  provide:"SocialAuthServiceConfig",
  useValue:{
    autoLogin:false,
    providers:[
      {
        id:GoogleLoginProvider.PROVIDER_ID,
        provider:new GoogleLoginProvider("471781467833-if3vbn4pl9r79igb9vak1v9acfmelrkl.apps.googleusercontent.com")
      }
    ],
    onerror:err=>console.log(err)
  } as SocialAuthServiceConfig
},
{provide:HTTP_INTERCEPTORS,useClass:HttpErrorHandlerInterceptorService,multi:true}
 


],
  bootstrap: [AppComponent],
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
