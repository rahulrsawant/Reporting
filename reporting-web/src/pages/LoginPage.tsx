import { useState, type FormEvent } from 'react'
import { useNavigate } from 'react-router'

function LoginPage() {
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const [error, setError] = useState('') // NEW
    const navigate = useNavigate()

    // NEW: "async" added
    async function handleSubmit(event: FormEvent) {
        event.preventDefault()
        setError('')

        // NEW: call the API
        const response = await fetch('/api/auth/login?useCookies=true', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ email, password }),
        })

        // NEW: if login failed, show a message and stop
        if (!response.ok) {
            setError('Login failed. Check your email and password.')
            return
        }

        // NEW: read the JSON from the response
        navigate('/')
    }

    return (
        <form onSubmit={handleSubmit}>
            <h1>Login</h1>

            <div>
                <label>Email</label>
                <input
                    type="email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />
            </div>

            <div>
                <label>Password</label>
                <input
                    type="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
            </div>

            {/* NEW: only shows when there is an error */}
            {error && <p style={{ color: 'red' }}>{error}</p>}

            <button type="submit">Log in</button>
        </form>
    )
}

export default LoginPage