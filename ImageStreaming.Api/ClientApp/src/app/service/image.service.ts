import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { IImageService } from '../core/services/IImage.service';
import { ImageEntity } from '../entity/image.entity';
import { IImageRepository } from '../core/repositories/IImage.repository';

@Injectable()
export class ImageService extends IImageService {
  constructor(private ImageRepository: IImageRepository) {
    super();
  }

  getLatestImage(): Observable<ImageEntity> {
    return this.ImageRepository.getLatestImage();
  }
}
