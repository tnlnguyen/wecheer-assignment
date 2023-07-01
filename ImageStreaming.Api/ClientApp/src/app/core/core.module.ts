import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BaseUrlInterceptor } from './base/base-url.inteceptor';
import { environment } from 'src/environments/environment.development';

@NgModule({
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: BaseUrlInterceptor,
      multi: true,
    },
    {
      provide: 'BASE_API_URL',
      useValue: environment.apiUrl,
    },
		{
      provide: 'VERSION',
      useValue: environment.version,
    },
  ],
})
export class CoreModule {}
