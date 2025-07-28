import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CountriesService } from 'src/app/services/countries.service';
import { CountryDto } from 'src/app/types/country/CountryDto';

@Component({
  selector: 'app-remove-country',
  templateUrl: './remove-country.component.html',
  styleUrls: ['./remove-country.component.css']
})
export class RemoveCountryComponent implements OnInit {
  countries?: CountryDto[];
  
  constructor(private countriesService: CountriesService) { }

  ngOnInit(): void {
     this.countryForm.controls.country.disable();

    this.countriesService.getAll().subscribe({
      next: (countries) => {
        this.countries = countries;
        console.log(this.countries);
        this.countryForm.controls.country.enable();
      },
      error: (error) => {
        console.error('Calling API failed', error);
      },
    })
  }

  countryForm = new FormGroup({
    country: new FormControl<number>(0, [
      Validators.required,
    ]),
    });
  
  RemoveCountry(e: Event): void {
      e.preventDefault();
      if (this.countryForm.invalid) return;
    
      this.countriesService.delete(this.countryForm.value.country!).subscribe({
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
