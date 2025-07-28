import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CitiesService } from 'src/app/services/cities.service';
import { CityDto } from 'src/app/types/city/CityDto';

@Component({
  selector: 'app-remove-city',
  templateUrl: './remove-city.component.html',
  styleUrls: ['./remove-city.component.css']
})
export class RemoveCityComponent implements OnInit {
  cities?: CityDto[];
  
  constructor(private citiesService: CitiesService) { }

  ngOnInit(): void {
     this.cityForm.controls.city.disable();

    this.citiesService.getAll().subscribe({
      next: (cities) => {
        this.cities = cities;
        console.log(this.cities);
         this.cityForm.controls.city.enable();
      },
      error: (error) => {
        console.error('Calling API failed', error);
      },
    })
  }

  cityForm = new FormGroup({
    city: new FormControl<number>(0, [
      Validators.required,
    ]),
    });
  
  RemoveCity(e: Event): void {
      e.preventDefault();
      if (this.cityForm.invalid) return;
    
      this.citiesService.delete(this.cityForm.value.city!).subscribe({
        next: () => {
         alert("Deleted successfully");
             window.location.reload();
        },
        error: () => {
          alert('Deleted failed');
        },
      })
    }
  
}
