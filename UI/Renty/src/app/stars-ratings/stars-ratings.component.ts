import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-stars-ratings',
  templateUrl: './stars-ratings.component.html',
  styleUrls: ['./stars-ratings.component.css']
})
export class StarsRatingsComponent  {

  @Input() rating?: number;
  get checkedStars() {
    return Array(Math.floor(this.rating!)).fill(0);
  }

  get uncheckedStars() {
    return Array(Math.floor(5-this.rating!)).fill(0);
  }


}
