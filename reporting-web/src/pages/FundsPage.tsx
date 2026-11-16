import { useEffect, useState } from 'react'
import { useNavigate } from 'react-router'

type Fund = {
  fundId: number
  fundCode: string
  fundName: string
  fundDomicile: string | null
  fundCurrency: string | null
  clientId: number
  createDate: string
}

function FundsPage() {
  const [funds, setFunds] = useState<Fund[]>([])
  const [loading, setLoading] = useState(true)
  const [error, setError] = useState('')
  const navigate = useNavigate()

  useEffect(() => {
    async function loadFunds() {
      const response = await fetch('/api/funds')

      if (response.status === 401) {
        navigate('/login')
        return
      }

      if (!response.ok) {
        setError('Could not load funds.')
        setLoading(false)
        return
      }

      const data: Fund[] = await response.json()
      setFunds(data)
      setLoading(false)
    }

    loadFunds()
  }, [navigate])

  if (loading) {
    return <p>Loading funds...</p>
  }

  if (error) {
    return <p style={{ color: 'red' }}>{error}</p>
  }

  return (
    <div>
      <h1>Funds</h1>

      <table>
        <thead>
          <tr>
            <th>Code</th>
            <th>Name</th>
            <th>Domicile</th>
            <th>Currency</th>
            <th>Created</th>
          </tr>
        </thead>
        <tbody>
          {funds.map((fund) => (
            <tr key={fund.fundId}>
              <td>{fund.fundCode}</td>
              <td>{fund.fundName}</td>
              <td>{fund.fundDomicile ?? '-'}</td>
              <td>{fund.fundCurrency ?? '-'}</td>
              <td>{new Date(fund.createDate).toLocaleDateString()}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}

export default FundsPage