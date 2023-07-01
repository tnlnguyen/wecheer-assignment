import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ImageComponent } from "./image/image.component";
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';

@NgModule({
  declarations: [
    ImageComponent,
  ],
  imports:[
    CommonModule,
		MatCardModule,
		MatButtonModule
  ],
  exports:[
    ImageComponent,
  ]
})
export class PresentationModule { }