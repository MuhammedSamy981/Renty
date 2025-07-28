import { ProductDto } from "../product/ProductDto";

export interface WishlisUpdateOrCreateDto {
  id: string | null;
  productIds: number[] | null;
}