import { Component, OnInit } from '@angular/core';
import { IImageService } from 'src/app/core/services/IImage.service';
import { ImageEntity } from 'src/app/entity/image.entity';
import { Observable, Subscription, flatMap, interval, startWith } from 'rxjs';

@Component({
  selector: 'app-image',
  templateUrl: 'image.component.html',
  styleUrls: ['image.component.css'],
})
export class ImageComponent implements OnInit {
	image: ImageEntity | undefined;
	streamData: Subscription | undefined;
	
	constructor(private ImageService: IImageService) {}

  ngOnInit() {
		this.streamData = interval(5000).pipe(
			startWith(0),
			flatMap(() => this.ImageService.getLatestImage())
		).subscribe((data: ImageEntity) => {
			this.image = data;
    });
	}
}
