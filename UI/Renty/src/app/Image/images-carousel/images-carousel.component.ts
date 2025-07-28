
import { Component, Input } from '@angular/core';
import { ImageDto } from 'src/app/types/image/ImageDto';


@Component({
  selector: 'app-images-carousel',
  templateUrl: './images-carousel.component.html',
  styleUrls: ['./images-carousel.component.css']
})
export class ImagesCarouselComponent {
 carousel: any;
 @Input() images:ImageDto[]=[];
 
}