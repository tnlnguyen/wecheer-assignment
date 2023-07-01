import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { ImageEntity } from 'src/app/entity/image.entity';
import { IImageRepository } from 'src/app/core/repositories/IImage.repository';

@Injectable()
export class ImageRepository extends IImageRepository {
  constructor(private http: HttpClient) {
    super();
  }

  getLatestImage(): Observable<ImageEntity> {
    return this.http.get<ImageEntity>('event/get-latest');
  }
}
