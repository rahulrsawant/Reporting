//this component is used to protect routes that require authentication. It checks if the user is logged in by making a request to the server. If the user is not logged in, it redirects them to the login page. If the user is logged in, it renders the child routes using an Outlet.
import { useEffect, useState } from 'react'
import { Navigate, Outlet } from 'react-router'

function RequireAuth() {
  const [status, setStatus] = useState('checking')

  useEffect(() => {
    async function checkLogin() {
      const response = await fetch('/api/auth/manage/info')
      setStatus(response.ok ? 'loggedIn' : 'loggedOut')
    }

    checkLogin()
  }, [])

  if (status === 'checking') {
    return <p>Loading...</p>
  }

  if (status === 'loggedOut') {
    return <Navigate to="/login" replace />
  }

  return <Outlet />
}

export default RequireAuth