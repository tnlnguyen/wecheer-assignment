import { NgModule } from "@angular/core";
import { IImageRepository } from "../core/repositories/IImage.repository";
import { IImageService } from "../core/services/IImage.service";
import { ImageRepository } from "../persistence/repository/image.repository";
import { ImageService } from "./image.service";

@NgModule({
	providers: [
			{provide: IImageRepository, useClass: ImageRepository},
			{provide: IImageService, useClass: ImageService},
		]
})

export class ServiceModule{}