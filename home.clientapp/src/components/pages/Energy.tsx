import { LoadComponendWithData } from '../../core/LoadComponentWithData';
import { EnergyDto } from '../../dtos/EnergyDto';
import { Card } from '../shared/Card/Card';
import { Fieldset } from '../shared/Fieldset/Fieldset';

export function Energy() {
    return LoadComponendWithData("api/energy/currentpower", ((data: EnergyDto) =>
    (
        <Fieldset title="Energia">
            <Card title="Moc produkowana" value={data.production} unit="W" percentage={55} percentageColor="green"></Card>
            <Card title="Moc pobierana" value={data.import} unit="W" percentage={34} percentageColor="yellow"></Card>
            <Card title="Moc oddawana" value={data.export} unit="W" percentage={20} percentageColor="yellow"></Card>
            <Card title="Moc zużywana" value={data.consumption} unit="W" percentage={60} percentageColor="red"></Card>
            <Card title="Moc wykorzystywana" value={data.use} unit="W" percentage={20} percentageColor="yellow"></Card>
            <Card title="Moc magazynowana" value={data.store} unit="W" percentage={25} percentageColor="yellow"></Card>
        </Fieldset>
    )), 5000);
}