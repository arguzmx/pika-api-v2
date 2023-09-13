﻿using api.comunes.modelos.modelos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace api.comunes;

/// <summary>
/// Extensión de resgiro para el middleware de entidad API
/// </summary>
public static class EntidadAPIMiddlewareExtensions
{
    /// <summary>
    /// Identificador par el encabezado de identficación de dominio
    /// </summary>
    public const string DOMINIOHEADER = "x-d-id";

    /// <summary>
    /// Identificador par el encabezado de identficación de unidad organizacional
    /// </summary>
    public const string UORGHEADER = "x-uo-id";

    /// <summary>
    /// Identificador par el encabezado de detección de idioma
    /// </summary>
    public const string IDIOMAHEADER = "Accept-Language";

    /// <summary>
    /// nombre del header de autenticacion
    /// </summary>
    public const string JWTAHEADER = "Authorization";

    public static IServiceCollection AddServiciosEntidadAPI(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        return services;
    }

    public static IApplicationBuilder UseEntidadAPI(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<EntidadAPIMiddleware>();
    }

    /// <summary>
    /// Devuleve
    /// </summary>
    /// <param name="context"></param>
    /// <param name="requiereAutenticacion"></param>
    /// <returns></returns>
    public static ContextoUsuario ObtieneContextoUsuario(this HttpContext context)
    {
        var demo = AtributosSeguridadJWT(context);
        ContextoUsuario contextoUsuario = new()
        {
            DominioId = context.Request.Headers?[DOMINIOHEADER],
            Idioma = context.Request.Headers?[IDIOMAHEADER],
            UOrgId = context.Request.Headers?[UORGHEADER],
            UsuarioId = demo.usuarioId,
            Clains = demo.claims,
            TokenAutenticacion = demo.token
        };
        return contextoUsuario;
    }


    /// <summary>
    /// Devulve los atributos de seguridad extraidos del token JWT del usaurio
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static (string? token, string? usuarioId, List<Claim>? claims) AtributosSeguridadJWT(HttpContext context)
    {
        string? token = null;
        string? usuarioId = null;
        List<Claim>? claims = null;

        string? authHeader = context.Request.Headers?[UORGHEADER];
        if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer"))
        {
            token = authHeader.Split(" ")[1];
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
            claims = jwt.Claims.ToList();
            usuarioId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        return (token, usuarioId, claims);
    }


}

