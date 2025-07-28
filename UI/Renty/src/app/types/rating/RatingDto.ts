export interface RatingDto {
  id: number;
  fullName: string;
  value: number;
  comment: string;
  datetime: string;
  productId: number;
  userId: string | null;
}
