import React, { useState } from 'react';
import axios from 'axios';

const PrimeCheck = () => {
    const [number, setNumber] = useState('');
    const [result, setResult] = useState(null);
    const [version, setVersion] = useState('');

    const fetchVersion = async () => {
        try {
            const response = await axios.get('http://localhost:31594/api/prime/version');
            setVersion(response.data.version);
        } catch (error) {
            console.error('Error fetching API version:', error);
        }
    };

    const checkPrime = async () => {
        try {
            const response = await axios.get(`http://localhost:31594/api/prime/isprime/${number}`);
            setResult(response.data);
        } catch (error) {
            console.error('Error checking prime number:', error);
        }
    };

    return (
        <div>
            <h1>Prime Number Checker</h1>
			<h2> Implementación completa v2</h2>
            <button onClick={fetchVersion}>Get API Version</button>
            <p>API Version: {version}</p>
            <input
                type="number"
                value={number}
                onChange={(e) => setNumber(e.target.value)}
                placeholder="Enter a number"
            />
            <button onClick={checkPrime}>Check</button>
            {result && (
                <div>
                    <p>Number: {result.number}</p>
                    <p>Is Prime: {result.isPrime ? 'Yes' : 'No'}</p>
                </div>
            )}
        </div>
    );
};

export default PrimeCheck;
