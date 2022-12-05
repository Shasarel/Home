export interface ElectricityChartDataDto {
    production: number|null[],
    consumption: number | null[],
    use: number | null[],
    import: number | null[],
    export: number | null[],
    store: number |null[],
    labels: string[],
    chartType: string,
}