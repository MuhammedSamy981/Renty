import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CitiesService } from 'src/app/services/cities.service';
import { CountriesService } from 'src/app/services/countries.service';
import { CityAddDto } from 'src/app/types/city/CityAddDto';
import { CountryDto } from 'src/app/types/country/CountryDto';

@Component({
  selector: 'app-add-city',
  templateUrl: './add-city.component.html',
  styleUrls: ['./add-city.component.css']
})
export class AddCityComponent implements OnInit {
  
  lastId?:number;
  countries?:CountryDto[];
  
  constructor(private citiesService: CitiesService,private countriesService:CountriesService) { }

  ngOnInit(): void {
      this.cityForm.controls.country.disable();

    this.citiesService.getAll()
    .subscribe(cities=> this.lastId = cities.length);

    this.countriesService.getAll().subscribe({
      next: (countries) => {
        this.countries = countries;
         this.cityForm.controls.country.enable();
      },
      error: (error) => {
        console.error('Calling API failed', error);
      },
    })
  }

  cityForm = new FormGroup({
      name: new FormControl<string>('', [
        Validators.required,
      ]),
      country: new FormControl<number>(0, [
        Validators.required,
      ]),
    });
  
  AddCity(e: Event): void {
      e.preventDefault();
      if (this.cityForm.invalid) return;

      const city: CityAddDto =
      {
        id: this.lastId! + 1,
        name: this.cityForm.value.name!,
        countryId: this.cityForm.value.country as any
      };
    
      this.citiesService.add(city).subscribe({
        next: () => {
         alert("Added successfully");
             window.location.reload();
        },
        error: () => {
          alert('Added failed');
        },
      })
    }
  
}

