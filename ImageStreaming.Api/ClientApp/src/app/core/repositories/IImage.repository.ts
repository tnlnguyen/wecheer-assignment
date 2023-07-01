import { Observable } from "rxjs";
import { ImageEntity } from "src/app/entity/image.entity";

export abstract class IImageRepository {
    abstract getLatestImage(): Observable<ImageEntity>;
}