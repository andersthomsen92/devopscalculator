import http from 'k6/http';
import { sleep, check } from 'k6';

// Define spike load
export const options = {
    stages: [
        { duration: '10s', target: 10 },   // Ramp-up to 10 users in 10 sec
        { duration: '20s', target: 100 },  // Sudden spike to 100 users in 20 sec
        { duration: '10s', target: 10 },   // Ramp-down to 10 users in 10 sec
    ],
};

const API_BASE_URL = 'http://localhost:5000/api/calculator';

export default function () {
    const payload = JSON.stringify({ A: 10, B: 5 });

    const params = {
        headers: { 'Content-Type': 'application/json' },
    };

    const res = http.post(`${API_BASE_URL}/simple/add`, payload, params);

    check(res, {
        'Status is 200': (r) => r.status === 200,
        'Response time < 500ms': (r) => r.timings.duration < 500,
    });

    sleep(1);
}
