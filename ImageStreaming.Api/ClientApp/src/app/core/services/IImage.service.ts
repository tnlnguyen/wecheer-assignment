import { Observable } from "rxjs";
import { ImageEntity } from "src/app/entity/image.entity";

export abstract class IImageService {
    abstract getLatestImage(): Observable<ImageEntity>;
}