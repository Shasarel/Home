import React from 'react';
import { Card } from '../shared/Card';
import { Fieldset } from '../shared/Fieldset';


export function Home() {
    return (
        <Fieldset title="Energia">
            <Card title="Dzienna produkcja" value={2.54} unit="kWh" percentage={50} percentageColor="green"></Card>
            <Card title="Dzienne zużycie" value={13.46} unit="kWh" percentage={50} percentageColor="red"></Card>
            <Card title="Całkowity blians" value={3442.63} unit="kWh" percentage={50} percentageColor="yellow"></Card>
        </Fieldset>
    );
}
