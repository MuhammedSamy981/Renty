import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CountriesService } from 'src/app/services/countries.service';
import { CountryAddDto } from 'src/app/types/country/CountryAddDto';

@Component({
  selector: 'app-add-country',
  templateUrl: './add-country.component.html',
  styleUrls: ['./add-country.component.css']
})
export class AddCountryComponent implements OnInit {
  
  lastId?:number;
  
  constructor(private countriesService: CountriesService) { }

  ngOnInit(): void {
    this.countriesService.getAll()
    .subscribe(countries=> this.lastId = countries.length);
  }

  countryForm = new FormGroup({
      name: new FormControl<string>('', [
        Validators.required,
      ])
    });
  
  AddCountry(e: Event): void {
      e.preventDefault();
      if (this.countryForm.invalid) return;

      const country: CountryAddDto =
      {
        id: this.lastId!+1,
        name: this.countryForm.value.name!,
      };
    
      this.countriesService.add(country).subscribe({
        next: () => {
         alert("Added successfully");
             window.location.reload();
        },
        error: (error) => {
          alert('Added failed');
        },
      })
    }
  
}

