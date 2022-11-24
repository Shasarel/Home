import { wait } from '@testing-library/user-event/dist/utils';
import React, { useEffect, useState } from 'react';
import { Card } from '../shared/Card';
import { Fieldset } from '../shared/Fieldset';


export function Home() {
    const [data, setData] = useState("");

    useEffect(() => {
            fetch("/energy")
                .then(response => response.text()
                    .then(text => setData(text)))
    }, []);

    return (
        <Fieldset title="Energia">
            <Card title="Dzienna produkcja" value={2.54} unit="kWh" percentage={50} percentageColor="green"></Card>
            <Card title="Dzienne zużycie" value={13.46} unit="kWh" percentage={50} percentageColor="red"></Card>
            <Card title="Dzienny bilans" value={-11.46} unit="kWh" percentage={50} percentageColor="red"></Card>
            <Card title="Całkowity blians" value={3442.63} unit="kWh" percentage={50} percentageColor="yellow"></Card>
        </Fieldset>
    );
}
