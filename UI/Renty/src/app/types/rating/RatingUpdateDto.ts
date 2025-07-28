export interface RatingUpdateDto {
  id: number;
  value: number;
  comment: string;
  productId: number;
  userId: string | null;
}

