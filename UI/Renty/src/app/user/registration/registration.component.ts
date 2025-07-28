import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AreasService } from 'src/app/services/areas.service';
import { CitiesService } from 'src/app/services/cities.service';
import { CountriesService } from 'src/app/services/countries.service';
import { UsersService } from 'src/app/services/users.service';
import { AreaDto } from 'src/app/types/area/AreaDto';
import { CityDto } from 'src/app/types/city/CityDto';
import { CountryDto } from 'src/app/types/country/CountryDto';
import { RegisterDto } from 'src/app/types/user/RegisterDto';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  countries?: CountryDto[];

  cities?: CityDto[];

  areas?: AreaDto[];


  constructor( private usersService: UsersService,
      private countriesService:CountriesService,
      private citiesService:CitiesService,
      private areasService:AreasService,
      private router: Router
  )
  {}
  
  ngOnInit(): void {
   this.registerForm.controls.country.disable();
   this.registerForm.controls.city.disable();
   this.registerForm.controls.area.disable();

   this.countriesService.getAll().subscribe({
    next: (countries) => {
      this.countries = countries;
      this.registerForm.controls.country.enable();
    },
    error: (error) => {
      console.error('Calling API failed', error);
    },
  })
  }

  
  onCountryChange(): void {

    this.citiesService.getAllByCountryId(this.registerForm.value.country!).subscribe({
      next: (cities) => {
        this.cities = cities;
        this.registerForm.controls.city.enable();
        this.registerForm.controls.city.setValue(0);
        console.log(this.cities);
        
        
      },
      error: (error) => {
        console.error('Calling API failed', error);
      },
    })

}

onCityChange(): void {

    this.areasService.getAllByCityId(this.registerForm.value.city!).subscribe({
      next: (areas) => {
        this.areas = areas;
        this.registerForm.controls.area.enable();
        this.registerForm.controls.area.setValue(0);
        console.log(this.areas);
      },
      error: (error) => {
        console.error('Calling API failed', error);
      },
    })
  

}

registerForm=new FormGroup({
  firstName: new FormControl<string>('',[
    Validators.maxLength(10),
    Validators.required
  ]),
    lastName: new FormControl<string>('',[
    Validators.maxLength(10),
    Validators.required
  ]),  
  email: new FormControl<string>('',[
    Validators.required,
    Validators.email
  ]),
  password: new FormControl<string>('',[
    Validators.required,
    Validators.minLength(8)
  ]),
   confirmPassword: new FormControl<string>('', [
  ]),
  phoneNumber: new FormControl<string>('',[
    Validators.required,
    Validators.minLength(11)
  ]),
  country: new FormControl<number>(0, [
    Validators.min(1),
  ]),
  city: new FormControl<number>(0, [
    Validators.min(1),
  ]),
  area: new FormControl<number>(0, [
    Validators.min(1),
  ]),
},{ validators: this.passwordsMatchValidator })

  // Custom validator
  passwordsMatchValidator(group: AbstractControl): ValidationErrors | null {
    const password = group.get('password')?.value;
    const confirm = group.get('confirmPassword')?.value;
    return password === confirm ? null : { passwordsMismatch: true };
  }
  

  Signup(e:Event):void{
    e.preventDefault();
    if(this.registerForm.invalid) 
      {return;}
      const register : RegisterDto=
      {
        firstName:  this.registerForm.value.firstName!,
        lastName:  this.registerForm.value.lastName!,
        email: this.registerForm.value.email!,
        password: this.registerForm.value.password!,
        phoneNumber: this.registerForm.value.phoneNumber!,
        countryId: this.registerForm.value.country!,
        cityId: this.registerForm.value.city!,
        areaId: this.registerForm.value.area!,
        
      }
      console.log(register)
    this.usersService.register(register).subscribe(
      {
        next:()=>
        {
          alert("Register successfully");
          this.router.navigateByUrl("/");
      },
      error: () => {
        alert('Register failed');
      },
      }
    )
  }
}

