import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpStatusCode } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, of } from 'rxjs';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../ui/custom-toastr.service';
import { MessageType } from '../admin/alertify.service';
import { UserAuthServiceService } from './models/user-auth.service.service';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from 'src/app/base/base.component';

@Injectable({
  providedIn: 'root'
})
export class HttpErrorHandlerInterceptorService implements HttpInterceptor {

  constructor(private toastrService:CustomToastrService ,private userAuthService:UserAuthServiceService,private rouete:Router,
    private spinner:NgxSpinnerService){ }




  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
  return next.handle(req).pipe(catchError(error=>{
    switch(error.status){
      case HttpStatusCode.Unauthorized:
        
         this.userAuthService.refreshTokenLogin(localStorage.getItem("refreshToken"),(state)=>{
         if(!state) 
         {
          const url=this.rouete.url;
          if(url=="/animals") 
           this.toastrService.message("Başvurunu için oturum açınız","Oturum açınız!",{
             messageType:ToastrMessageType.Warning,
             position:ToastrPosition.TopRight
           });  
 
          else
           this.toastrService.message("Bu işlem için yetkin yok","Yetkisiz işlem",{
             messageType:ToastrMessageType.Warning,
             position:ToastrPosition.TopRight
           }); 
         }
         }).then(data=>{
          
        });


     break;
         
      case HttpStatusCode.InternalServerError:
      this.toastrService.message("Sunucuya erişilemiyor","Sunucu erişimi yok",{
        messageType:ToastrMessageType.Warning,
        position:ToastrPosition.TopRight
      });
      break;

        case HttpStatusCode.BadRequest:
        this.toastrService.message("Geçersiz istek yapıldı","Geçersiz istek",{
          messageType:ToastrMessageType.Warning,
          position:ToastrPosition.TopRight
        });
        break;


          case HttpStatusCode.NotFound:
        this.toastrService.message("Sayfa bulunamadı","Sayfa bulunamadı",{
          messageType:ToastrMessageType.Warning,
          position:ToastrPosition.TopRight
        });
          break;

          default:
            
        this.toastrService.message("Beklenmeyen bir hata oluştu","hata",{
          messageType:ToastrMessageType.Warning,
          position:ToastrPosition.TopRight
        });
            break;
      
      }

      this.spinner.hide(SpinnerType.BallAtom);
     return of (error);
    }));
    


  }



}
