import React, { useState } from 'react'
import { Link, useHistory } from 'react-router-dom'
import { FiEdit, FiTrash2 } from 'react-icons/fi'
import './styles.css'
import logoImage from '../../assets/logo.svg'
import api from '../../services/api'

export default function BookCatalog() {
  return (
    <div className="bookCatalog-container">
      <header>
        <img src={logoImage} alt="Catálogo de livros" />
        <span>Catálogo de Livros</span>
        <Link className="button" to="/NewBook">Adicionar novo livro</Link>
      </header>
      <h1>Livros Registrados</h1>
      <ul>
        <li>
          <strong>Título:</strong>
          <p>Adams Óbvio</p>
          <strong>Autor:</strong>
          <p>Robert R. Updegraff</p>
          <strong>Editora:</strong>
          <p>Faro Editorial</p>
          <strong>Ano de Publicação:</strong>
          <p>2015</p>
          <strong>Edição:</strong>
          <p>1ª</p>
          <button type="button">
            <FiEdit size={20} color="#251FC5" />
          </button>
          <button type="button">
            <FiTrash2 size={20} color="#251FC5" />
          </button>
        </li>
        <li>
          <strong>Título:</strong>
          <p>Adams Óbvio</p>
          <strong>Autor:</strong>
          <p>Robert R. Updegraff</p>
          <strong>Editora:</strong>
          <p>Faro Editorial</p>
          <strong>Ano de Publicação:</strong>
          <p>2015</p>
          <strong>Edição:</strong>
          <p>1ª</p>
          <button type="button">
            <FiEdit size={20} color="#251FC5" />
          </button>
          <button type="button">
            <FiTrash2 size={20} color="#251FC5" />
          </button>
        </li>
        <li>
          <strong>Título:</strong>
          <p>Adams Óbvio</p>
          <strong>Autor:</strong>
          <p>Robert R. Updegraff</p>
          <strong>Editora:</strong>
          <p>Faro Editorial</p>
          <strong>Ano de Publicação:</strong>
          <p>2015</p>
          <strong>Edição:</strong>
          <p>1ª</p>
          <button type="button">
            <FiEdit size={20} color="#251FC5" />
          </button>
          <button type="button">
            <FiTrash2 size={20} color="#251FC5" />
          </button>
        </li>
        <li>
          <strong>Título:</strong>
          <p>Adams Óbvio</p>
          <strong>Autor:</strong>
          <p>Robert R. Updegraff</p>
          <strong>Editora:</strong>
          <p>Faro Editorial</p>
          <strong>Ano de Publicação:</strong>
          <p>2015</p>
          <strong>Edição:</strong>
          <p>1ª</p>
          <button type="button">
            <FiEdit size={20} color="#251FC5" />
          </button>
          <button type="button">
            <FiTrash2 size={20} color="#251FC5" />
          </button>
        </li>
      </ul>
    </div>
  )
}