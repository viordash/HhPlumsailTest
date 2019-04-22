export interface OrderModel {
    id: number;
    date: Date;
    customer: string;
    status: object;
    prepaid: boolean;
    summ: number;
    description: string;
}
